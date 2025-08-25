import { Component, OnInit } from '@angular/core';
import { LocationService } from '../services/location.service';
import { EquipementLocation } from '../models/EquipementLocation';
import {  EquipementCardComponent} from '../equipement-card/equipement-card.component'; 
import{ CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';



@Component({
  selector: 'home',
  standalone: true,
  imports: [EquipementCardComponent, CommonModule],
  templateUrl: './home.component.html',
  styleUrl:'./home.component.css'
})

export class HomeComponent implements OnInit {

  equipements: EquipementLocation[] = [];

  constructor(private locationService: LocationService, private toastr: ToastrService) {}

  ngOnInit(): void {
    this.getLocationEquipement();
  }
getLocationEquipement() {
  this.locationService.getEquipements().subscribe({
    next: data => this.equipements = data,
    error: err => this.toastr.error(err)
  });
}
}

