import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ICountry } from './country';
import { CountriesService } from './countries.service'

@Component({
    moduleId: module.id + '',
    templateUrl: 'xr-collect.component.html'
})
export class XrCollectComponent implements OnInit {

    countries: ICountry[]
    selectedCountryValue: string = "-1";
    loadingMessage: string = "Loading countries...";
    errorMessage: string;
    private loadTimeoutSeconds: number = 8;

    constructor(private _router: Router, private _countriesService: CountriesService) { }

    ngOnInit(): void {
        setTimeout(() => { this.loadingMessage = "Still loading... please wait."; }, this.loadTimeoutSeconds * 1000);
        var prompt : ICountry = {
            id: "-1",
                    name: "Please select a country",
                    currency: null,
                    localProduct: null
        };
        this._countriesService.getCountries()
            .subscribe(c => {
            this.countries = c;
                this.countries.unshift(prompt)
            },
            error => this.errorMessage = <any>error);
    }

    onSubmit(form: any): void {
        this._router.navigate(['verdict'], { queryParams: { amount: form.amount, countryId: form.countryId } });
    }
}