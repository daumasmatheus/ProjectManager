import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AvatarModule } from 'ngx-avatar';
import { HttpClientModule } from '@angular/common/http';
import { FlexLayoutModule } from '@angular/flex-layout';

import { DashboardRoutingModule } from './dashboard.route';
import { DashboardComponent } from './dashboard.app.component';
import { AngularMaterialModule } from 'src/app/angular-material.module';
import { NavigationModule } from '../navigation/navigation.module';
import { OverviewComponent } from './overview/overview.component';
import { TasksComponent } from './tasks/tasks.component';
import { ProjectsComponent } from './projects/projects.component';
import { JwtValidationGuard } from './guards/jwt-validation.guard';
import { ProfileComponent } from './profile/profile.component';

@NgModule({
    declarations: [
        DashboardComponent,
        OverviewComponent,        
        TasksComponent,
        ProjectsComponent,
        ProfileComponent        
    ],
    imports: [ 
        CommonModule,
        DashboardRoutingModule,
        AngularMaterialModule,
        FlexLayoutModule,
        NavigationModule,
        HttpClientModule,
        AvatarModule
    ],
    exports: [],
    providers: [JwtValidationGuard],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class DashboardModule {}