import { Component, OnInit } from '@angular/core';
import { ICountry } from './country';

@Component({
    moduleId: module.id,
    templateUrl: 'home.component.html'
})
export class HomeComponent implements OnInit{ 

    countries: ICountry[]

    ngOnInit(): void {
        this.countries = [];
        this.countries.push({id:1, name:"Sweden"});
        this.countries.push({id:2, name:"Republic of Ireland"});       
    }

    onSubmit() : void {
        alert('')
    }
}