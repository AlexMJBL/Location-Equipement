import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { EquipementLocation } from "../models/EquipementLocation";
import { map } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class LocationService {

    urlBase = 'https://localhost:7192/api/Equipement/';

    constructor(private http: HttpClient) { }

    getEquipements() {
        return this.http.get<EquipementLocation[]>(this.urlBase + 'Get');
    }
    louerEquipement(id: number, nbJours: number) {
        return this.http.post<{ message: string }>(this.urlBase + `LouerEquipement/${id}`, { nbJours });
    }
    annulerLocation(locationId: number) {
        return this.http.put<{ message: string }>(this.urlBase + `AnnulerLocation/${locationId}`, {});
    }
}
