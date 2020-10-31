import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WorkspaceComponent } from './workspace/workspace.component';
import { DashboardRoutingModule } from './dashboard.route';
import { DashboardComponent } from './dashboard.app.component';

@NgModule({
    declarations: [
        DashboardComponent,
        WorkspaceComponent
    ],
    imports: [ 
        CommonModule,
        DashboardRoutingModule
    ],
    exports: [],
    providers: [],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class DashboardModule {}