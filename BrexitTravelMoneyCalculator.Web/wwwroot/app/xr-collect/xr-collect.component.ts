import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ICountry } from './country';
import { CountriesService } from './countries.service'

@Component({
    moduleId: module.id,
    templateUrl: 'xr-collect.component.html'
})
export class XrCollectComponent implements OnInit{ 

    countries: ICountry[]
    selectedCountryValue: number = -1;
    errorMessage: string;

    constructor(private _router: Router, private _countriesService: CountriesService){}

    ngOnInit(): void {
                this._countriesService.getCountries()
                .subscribe(c => this.countries = c,
                           error => this.errorMessage = <any>error);   
    }

    onSubmit(form:any) : void {
        this._router.navigate(['verdict'], {queryParams: {amount: form.amount, countryId: form.countryId}});
    }
}