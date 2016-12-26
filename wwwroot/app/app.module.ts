import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent }  from './app.component';
import { XrCollectComponent }  from './xr-collect/xr-collect.component';

import { DropdownInvalidValueDirective } from './dropdown-invalidvalue.directive';

import { routing, appRoutingProviders } from './app.routing';
@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        routing
    ],
    providers: [
        appRoutingProviders
    ],
    declarations: [
        AppComponent,
        XrCollectComponent,
        DropdownInvalidValueDirective
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }