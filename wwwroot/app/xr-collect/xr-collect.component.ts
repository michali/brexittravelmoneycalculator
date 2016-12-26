import { Component, OnInit } from '@angular/core';
import { ICountry } from './country';

@Component({
    moduleId: module.id,
    templateUrl: 'xr-collect.component.html'
})
export class XrCollectComponent implements OnInit{ 

    countries: ICountry[]
    selectedCountryValue: number = -1;

    ngOnInit(): void {
        this.countries = [];
        this.countries.push({id:-1, name: "Please select a country"})
        this.countries.push({id:1, name:"Sweden"});
        this.countries.push({id:2, name:"Republic of Ireland"});       
    }

    onSubmit(form:any) : void {
        alert(form.country);
    }
}