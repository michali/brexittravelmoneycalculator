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
    
    noOfProducts: number;
    noOfProductsPreRef: number;
    productName: string;
    private sub: any;   
    errorMessage: string;
    constructor(private route:ActivatedRoute, private verdictService:VerdictService){}

    ngOnInit():void {
        let countryId: string;
        let amount: number;
        this.sub = this.route
        .params
        .subscribe(params => {
            amount = params['amount'];
            countryId = params['countryId'];
        });

        let country: ICountry;
        this.verdictService.getVerdict(countryId).subscribe(c => {
            country = c;
        },
        error => this.errorMessage = <any>error);
        this.noOfProductsPreRef = Math.floor((amount * country.currency.preRefExchangeRate) / country.localProduct.price);
        let noOfProductsPostRef = Math.floor((amount * country.currency.exchangeRate) / country.localProduct.price);
        this.noOfProducts = this.noOfProductsPreRef - noOfProductsPostRef;

        if (this.noOfProducts === 1)
        {
            this.productName = country.localProduct.nameSingular;
        }
        else
        {
            this.productName = country.localProduct.namePlural;
        }
    }
}