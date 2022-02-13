import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReceivingLocationRoutingModule } from './receiving-location-routing.module';
import { ReceivingLocationComponent } from './receiving-location.component';

import { MatTableModule } from '@angular/material/table';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';

@NgModule({
  declarations: [
    ReceivingLocationComponent
  ],
  imports: [
    CommonModule,
    ReceivingLocationRoutingModule,
    MatTableModule,
    MatTableDataSource,
    MatPaginatorModule,
    MatSortModule
  ]
})
export class ReceivingLocationModule { }
