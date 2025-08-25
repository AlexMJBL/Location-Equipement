import { Component, EventEmitter, Input, Output } from '@angular/core';
import { EquipementLocation } from '../models/EquipementLocation';
import { LocationService } from '../services/location.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'equipement-card',
  templateUrl: './equipement-card.component.html',
  styleUrl: './equipement-card.component.css',
  standalone: true,
  imports: []
})
export class EquipementCardComponent {
  @Input() equipement!: EquipementLocation; 
  @Output() updated = new EventEmitter<void>()
  
  constructor(private locationService: LocationService, private toastr: ToastrService) {}
  

   louerEquipement(equipementId: number, days: number) {
    this.locationService.louerEquipement(equipementId, days).subscribe({
      next: (res) => {
        this.updated.emit();
        this.toastr.success(res.message);},
      error: err => this.toastr.error(err)
    });
  }

  annulerLocation(equipementId: number) {
    this.locationService.annulerLocation(equipementId).subscribe({
      next: (res) => {
        this.updated.emit();
        this.toastr.success(res.message);
      },
      error: err => this.toastr.error(err)
    });
  }
}