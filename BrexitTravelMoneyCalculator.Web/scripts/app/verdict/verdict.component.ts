import { Component, OnInit } from '@angular/core';
import { VerdictService } from './verdict.service';
import { ActivatedRoute, Params } from "@angular/router";
import { ICountry } from "./country";

@Component({
    moduleId: module.id + '',
    templateUrl: 'verdict.component.html'
})
export class VerdictComponent implements OnInit {
    
    _country: ICountry;
    
    constructor(private _route:ActivatedRoute, private _verdictService:VerdictService){}

    ngOnInit():void {
        this._route.params.switchMap((params:Params) => this._verdictService.getVerdict(params['countryId']))
        .subscribe((country:ICountry) => this._country = country)
    }
}