import { SidebarService } from './../../services/sidebar-service.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor(private sidebarService: SidebarService) { }

  ngOnInit() { }

  toggleSidebar() {
    this.sidebarService.toggle();
  }

}
