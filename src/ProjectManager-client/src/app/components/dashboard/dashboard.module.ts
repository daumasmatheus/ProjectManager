import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard.route';
import { DashboardComponent } from './dashboard.app.component';
import { AngularMaterialModule } from 'src/app/angular-material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { NavigationModule } from '../navigation/navigation.module';

@NgModule({
    declarations: [
        DashboardComponent        
    ],
    imports: [ 
        CommonModule,
        DashboardRoutingModule,
        AngularMaterialModule,
        FlexLayoutModule,
        NavigationModule
    ],
    exports: [],
    providers: [],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class DashboardModule {}