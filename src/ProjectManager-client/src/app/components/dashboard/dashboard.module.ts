import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard.route';
import { DashboardComponent } from './dashboard.app.component';
import { AngularMaterialModule } from 'src/app/angular-material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { NavigationModule } from '../navigation/navigation.module';
import { OverviewComponent } from './overview/overview.component';
import { TasksComponent } from './tasks/tasks.component';
import { ProjectsComponent } from './projects/projects.component';

@NgModule({
    declarations: [
        DashboardComponent,
        OverviewComponent,        
        TasksComponent,
        ProjectsComponent        
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