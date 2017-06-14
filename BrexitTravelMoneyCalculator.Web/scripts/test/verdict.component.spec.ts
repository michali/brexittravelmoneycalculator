import 'zone.js/dist/proxy';
import 'zone.js/dist/sync-test';
import 'zone.js/dist/async-test';
import 'zone.js/dist/jasmine-patch';
import { TestBed, async, ComponentFixture } from '@angular/core/testing'; 
import { RouterTestingModule } from '@angular/router/testing';
import { FormGroup, ReactiveFormsModule } from '@angular/forms'; 
import { ActivatedRoute, Params } from "@angular/router";
import { VerdictComponent } from '../app/verdict/verdict.component'; 
import { VerdictService } from '../app/verdict/verdict.service';
import { Observable } from 'rxjs/Observable';
import { ICountry } from '../app/verdict/country';
import { Subject } from 'rxjs';
import { ActivatedRouteStub} from './activatedroute.stub';
import { BrowserDynamicTestingModule, platformBrowserDynamicTesting } from '@angular/platform-browser-dynamic/testing';
import {} from 'jasmine';
  
describe('Component: VerdictComponent', () => { 
    let component: VerdictComponent; 
    let fixture: ComponentFixture<VerdictComponent>;
    let verdictService: VerdictService;
    let verdictServiceStub : {
        getVerdict(countryId:string): Observable<ICountry>;
    };
    let activatedRouteStub: ActivatedRouteStub;
    let activatedRoute: ActivatedRoute;

    beforeEach(() => { 
        verdictServiceStub = {
            getVerdict : (c) => {
                var country : ICountry = {
                    name : "ES",
                    currency : {
                        code : "EUR",
                        exchangeRate:1.1,
                        preRefExchangeRate:1.4
                    },
                    localProduct: {
                        nameSingular:"product",
                        namePlural:"products",
                        price:140
                    }
                }
                return Observable.of(country);
            }
        }

        activatedRouteStub = new ActivatedRouteStub();

        TestBed.initTestEnvironment(BrowserDynamicTestingModule, platformBrowserDynamicTesting());

        TestBed.configureTestingModule({ 
            declarations: [VerdictComponent], 
            imports: [ReactiveFormsModule, RouterTestingModule], 
            providers:    [ {provide: VerdictService, useValue: verdictServiceStub },
             { provide: ActivatedRoute, useValue: activatedRouteStub } ] 
        }); 
 
        fixture = TestBed.createComponent(VerdictComponent); 
        component = fixture.componentInstance; 
        verdictService = TestBed.get(VerdictService);
        activatedRoute = TestBed.get(ActivatedRoute)
    }); 
 
    it('should fail', async(() => { 
        activatedRouteStub.testParams = { amount: 140 };
        fixture.detectChanges();
        expect(component.noOfProducts).toBe(2); 
    })) 
})