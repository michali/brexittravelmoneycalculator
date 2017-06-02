import { TestBed } from '@angular/core/testing'; 
import { FormGroup, ReactiveFormsModule } from '@angular/forms'; 
import { VerdictComponent } from '../app/verdict/verdict.component'; 
import { VerdictService } from "../app/verdict/verdict.service";
import { Observable } from "rxjs/Observable";
import { ICountry } from "../app/verdict/country";
import { Subject } from "rxjs";
import { async } from "@angular/core/testing";
import { ComponentFixture } from "@angular/core/testing";
import {} from 'jasmine';
 
describe('Component: VerdictComponent', () => { 
    let component: VerdictComponent; 
    let fixture: ComponentFixture<VerdictComponent>;
    let verdictService: VerdictService;
    let verdictServiceStub : {
        getVerdict(countryId:string): Observable<ICountry>;
    };
 
    beforeEach(() => { 
        verdictServiceStub = {
            getVerdict : (c) => {
                var country : ICountry = {
                    name : "UK",
                    currency : {
                        code : "",
                        exchangeRate:1,
                        preRefExchangeRate:1
                    },
                    localProduct: {
                        nameSingular:"",
                        namePlural:"",
                        price:1
                    }
                }
                return Observable.of(country);
            }
        }

        TestBed.configureTestingModule({ 
            declarations: [VerdictComponent], 
            imports: [ReactiveFormsModule], 
            providers:    [ {provide: VerdictService, useValue: verdictServiceStub } ] 
        }); 
 
        fixture = TestBed.createComponent(VerdictComponent); 
        component = fixture.componentInstance; 
        verdictService = TestBed.get(VerdictService);
    }); 
 
    it('should fail', async(() => { 
        fixture.detectChanges();
        expect(1).toBe(2); 
    })) 
})