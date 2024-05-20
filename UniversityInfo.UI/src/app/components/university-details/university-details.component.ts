import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UniversityInfo } from '../../models/UniversityInfo';

@Component({
  selector: 'app-university-details',
  standalone: true,
  imports: [],
  templateUrl: './university-details.component.html',
  styleUrl: './university-details.component.css'
})
export class UniversityDetailsComponent {
  university!: UniversityInfo;

  constructor(private route: ActivatedRoute) {}

  ngOnInit() {
    this.route.paramMap.subscribe((params) => {
      this.university = {
        id: parseInt(params.get('id')!),
        country: params.get('country')!,
        state_province: params.get('state_province')!,
        name: params.get('name')!,
        alpha_two_code: params.get('alpha_two_code')!,
        web_pages: [{ WebPageUrl: params.get('web_pages')!, universityId: parseInt(params.get('university')!), id: parseInt(params.get('domain')!)}],
        domains: [{ domainName: params.get('domains')!, universityId: parseInt(params.get('university')!), id: parseInt(params.get('domain')!)}],
      };
    });
  }
}
