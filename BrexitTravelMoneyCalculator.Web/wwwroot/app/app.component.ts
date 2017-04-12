import { Component } from '@angular/core';
import {CountriesService} from './xr-collect/countries.service';

@Component({
    moduleId: module.id,
    selector: 'app-root',
    templateUrl: 'app.component.html',
    providers: [ CountriesService ]
})

export class AppComponent { }