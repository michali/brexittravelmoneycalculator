import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ICountry } from './country';

@Component({
    moduleId: module.id,
    templateUrl: 'xr-collect.component.html'
})
export class XrCollectComponent implements OnInit{ 

    countries: ICountry[]
    selectedCountryValue: number = -1;

    constructor(private _router: Router){}

    ngOnInit(): void {
        this.countries = [];
        this.countries.push({id:-1, name: "Please select a country"})
        this.countries.push({id:1, name:"Sweden"});
        this.countries.push({id:2, name:"Republic of Ireland"});       
    }

    onSubmit(form:any) : void {
        this._router.navigate(['verdict', {amount: form.amount, countryId: form.countryId}]);
    }
}