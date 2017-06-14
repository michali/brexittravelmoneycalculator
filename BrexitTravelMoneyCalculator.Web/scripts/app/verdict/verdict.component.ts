import { Component, OnInit } from '@angular/core';
import { VerdictService } from './verdict.service';
import { ActivatedRoute, Params } from "@angular/router";
import { ICountry } from "./country";
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/observable/of';

@Component({
    moduleId: module.id + '',
    templateUrl: 'verdict.component.html'
})
export class VerdictComponent implements OnInit {
    
    _country: ICountry;
    noOfProducts: number;
    
    constructor(private _route:ActivatedRoute, private _verdictService:VerdictService){}

    ngOnInit():void {
        this._route.params.switchMap((params:Params) => this._verdictService.getVerdict(params['countryId']))
        .subscribe((country:ICountry) => this._country = country)

        this.noOfProducts = 15;
    }
}