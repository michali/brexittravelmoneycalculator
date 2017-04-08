import { Routes, RouterModule } from '@angular/router';
import { XrCollectComponent }  from './xr-collect/xr-collect.component';
import { VerdictComponent } from './verdict/verdict.component';

const appRoutes: Routes = [
    { path: '', component: XrCollectComponent },
    { path: 'verdict', component: VerdictComponent }
];

export const appRoutingProviders: any[] = [

];

export const routing = RouterModule.forRoot(appRoutes);