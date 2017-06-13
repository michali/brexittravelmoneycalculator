import 'zone.js/dist/proxy';
import 'zone.js/dist/sync-test';
import 'zone.js/dist/async-test';
import 'zone.js/dist/jasmine-patch';
import { TestBed, async, ComponentFixture } from '@angular/core/testing'; 
import { RouterTestingModule } from '@angular/router/testing';
import { FormGroup, ReactiveFormsModule } from '@angular/forms'; 
import { VerdictComponent } from '../app/verdict/verdict.component'; 
import { VerdictService } from '../app/verdict/verdict.service';
import { Observable } from 'rxjs/Observable';
import { ICountry } from '../app/verdict/country';
import { Subject } from 'rxjs';
import {BrowserDynamicTestingModule, platformBrowserDynamicTesting } from '@angular/platform-browser-dynamic/testing';
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
        TestBed.initTestEnvironment(BrowserDynamicTestingModule, platformBrowserDynamicTesting());

        TestBed.configureTestingModule({ 
            declarations: [VerdictComponent], 
            imports: [ReactiveFormsModule, RouterTestingModule], 
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