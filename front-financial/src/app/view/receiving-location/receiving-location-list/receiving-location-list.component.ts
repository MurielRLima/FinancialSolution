import { AfterViewInit, Component, OnInit } from '@angular/core';
import { IReceivingLocationData } from 'src/app/data/interfaces/registers/receiving-location.interface';
import { ReceivingLocationService } from '../service/receiving-location-service.service';

export interface ReceivingLocation {
  id?: string;
  description: string;
  observation: string;
  active: number;
}


@Component({
  selector: 'app-receiving-location-list',
  templateUrl: './receiving-location-list.component.html',
  styleUrls: ['./receiving-location-list.component.scss']
})
export class ReceivingLocationListComponent implements OnInit, AfterViewInit {
  dataSource: IReceivingLocationData[];
  displayedColumns: string[] = ['description', 'observation', 'active', 'act' ];


  constructor(public receivingLocationService: ReceivingLocationService) { }

  ngOnInit(): void {

  }

  ngAfterViewInit(): void {
      this.receivingLocationService.get().subscribe( data => {
        this.dataSource = data;
      });
  }

}
