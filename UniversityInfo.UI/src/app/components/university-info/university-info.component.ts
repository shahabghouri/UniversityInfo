import { Component, OnInit, TemplateRef, inject } from '@angular/core';
import { UniversityInfoService } from '../../services/university-info.service';
import { UniversityInfo } from '../../models/UniversityInfo';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-university-info',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './university-info.component.html',
  styleUrl: './university-info.component.css'
})
export class UniversityInfoComponent implements OnInit {
  universities: any[] = [];
  searchText: string = 'Pakistan';
  country: string = 'Pakistan'; // Set the country name here or get it dynamically
  loading: boolean = true;
  syncing: boolean = false;
  syncBtnText: string = 'Sync';
  error: string = '';
  universityForm: FormGroup = this.formBuilder.group({
    name: [''],
    country: [''],
    alphaTwoCode: [''],
    stateProvince: [''],
  });
  constructor(private universityService: UniversityInfoService, private router: Router, private formBuilder: FormBuilder) {}
  ngOnInit(): void {
    this.fetchUniversities();
  }
  fetchUniversities(): void {
    this.country = this.searchText;
    this.loading = true;
    this.universities = [];
    this.universityService.getUniversitiesByCountryNameHipolabs(this.country)
      .subscribe({
        next: (data) => {
          this.universities = data;
          this.loading = false;
        },
        error: (err) => {
          this.error = 'Failed to load universities';
          this.loading = false;
        }
      });
  }
  openUniversityDetails(university: UniversityInfo){
    this.router.navigate(['/university/details',university]);
  }
  syncUniversities(){
    this.syncing = true;
    this.syncBtnText = 'Syncing...';
    var universities = [];
    for(var i=0;i< this.universities.length;i++){
      var university = {
        id: this.universities[i].id,
        country: this.universities[i].country!,
        StateProvince: this.universities[i]["state-province"] ?? "",
        name: this.universities[i].name!,
        alphaTwoCode: this.universities[i].alpha_two_code!,
        webPages: [ this.universities[i].web_pages[0]],
        domains: [this.universities[i].domains[0]],
      };
      universities.push(university);
    }
    this.universityService.syncUniversities(universities).subscribe({
      next: (data) => {
        this.syncBtnText = 'Synced';
      },
      error: (err) => {
        this.error = 'Failed to sync universities';
        this.syncBtnText = 'Sync Failed!';
      }
    })
  }
  isEditing: boolean = false;
 
  submitEditUniversity(){
    var obj = this.universityForm.value;
    this.universityService.updateUniversity(obj).subscribe({
      next: (response)=>{
        if(response){

        }
      },
      error: (response) =>{

      }
    });
  }
  private modalService = inject(NgbModal);
	closeResult = '';

	editUniversity(content: TemplateRef<any>,university: any) {
    this.isEditing = false;
    this.universityForm.patchValue({
      name: university.name,
      alphaTwoCode: university.alpha_two_code,
      country: university.country,
      stateProvince: university["state-province"]
    });
		this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then(
			(result) => {
        this.submitEditUniversity()
				this.closeResult = `Closed with: ${result}`;
			},
			(reason) => {
				this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
			},
		);
	}

	private getDismissReason(reason: any): string {
		switch (reason) {
			case ModalDismissReasons.ESC:
				return 'by pressing ESC';
			case ModalDismissReasons.BACKDROP_CLICK:
				return 'by clicking on a backdrop';
			default:
				return `with: ${reason}`;
		}
	}
}
