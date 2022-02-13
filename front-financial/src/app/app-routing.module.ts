import { HomeComponent } from './view/home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ReceivingLocationComponent } from './view/receiving-location/receiving-location.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'receiving-location',
    component: ReceivingLocationComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
