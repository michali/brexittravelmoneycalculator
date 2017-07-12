import { Component } from '@angular/core';
import {CountriesService} from './xr-collect/countries.service';
import { VerdictService } from './verdict/verdict.service';

@Component({
    moduleId: module.id + '',
    selector: 'app-root',
    templateUrl: 'app.component.html',
    providers: [ CountriesService, VerdictService ]
})

export class AppComponent { }