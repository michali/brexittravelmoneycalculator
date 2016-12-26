import { Routes, RouterModule } from '@angular/router';
import { XrCollectComponent }  from './xr-collect/xr-collect.component';

const appRoutes: Routes = [
    { path: '', component: XrCollectComponent }
];

export const appRoutingProviders: any[] = [

];

export const routing = RouterModule.forRoot(appRoutes);