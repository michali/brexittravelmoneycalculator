//import { enableProdMode } from '@angular/core';
import 'zone.js';
import 'reflect-metadata';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule } from './app.module';

// Extend Observable through the app
import 'rxjs/Rx';

//enableProdMode();


platformBrowserDynamic().bootstrapModule(AppModule);