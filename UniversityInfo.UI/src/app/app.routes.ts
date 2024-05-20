import { Routes } from '@angular/router';
import { UniversityInfoComponent } from './components/university-info/university-info.component';
import { UniversityDetailsComponent } from './components/university-details/university-details.component';

export const routes: Routes = [
  {
    path: '',
    component: UniversityInfoComponent,
    title: 'Universities'
  },
  {
    path: 'university/details',
    component: UniversityDetailsComponent,
    title: 'University Details'
  },
];
