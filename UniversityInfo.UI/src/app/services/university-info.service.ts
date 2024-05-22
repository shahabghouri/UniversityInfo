import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UniversityInfo } from '../models/UniversityInfo';
import { Constant } from './constant/constant';

@Injectable({
  providedIn: 'root'
})
export class UniversityInfoService {

  constructor(private http: HttpClient) { }
  getUniversitiesByCountryNameHipolabs(Country: string): Observable<UniversityInfo[]> {
    return this.http.get<UniversityInfo[]>(Constant.API_END_POINT_hipolabs + Constant.METHODS.GET_UNIVERSITIES_Hipolabs + Country);
  }
  getUniversitiesByCountryName(Country: string): Observable<UniversityInfo> {
    return this.http.get<UniversityInfo>(Constant.API_END_POINT + Constant.METHODS.GET_UNIVERSITIES + Country);
  }
  createUniversity(data: UniversityInfo): Observable<UniversityInfo> {
    return this.http.post<UniversityInfo>(Constant.API_END_POINT + Constant.METHODS.CREATE_NEW_UNIVERSITY, data);
  }
  syncUniversities(data: any[]): Observable<boolean> {
    return this.http.post<boolean>(Constant.API_END_POINT + Constant.METHODS.SYNC_UNIVERSITIES, data);
  }
  updateUniversity(obj: any): Observable<any> {
    return this.http.put<any>(Constant.API_END_POINT + Constant.METHODS.UPDATE_UNIVERSITY_BY_NAME, obj);
  }
}
