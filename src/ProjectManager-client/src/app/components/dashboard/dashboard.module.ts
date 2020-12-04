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
import { JwtValidationGuard } from './guards/jwt-validation.guard';
import { ProfileComponent } from './profile/profile.component';
import { ProjectComponent } from './projects/project/project.component';
import { ProjectHeaderComponent } from './projects/project-header/project-header.component';
import { NewProjectComponent } from './projects/new-project/new-project.component';
import { TableComponentComponent } from './base-components/table-component/table-component.component';
import { AddTaskDialogComponent } from './projects/add-task-dialog/add-task-dialog.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MomentPipe } from 'src/app/helpers/moment.pipe';
import { FaIconLibrary, FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faChevronDown, faChevronUp, faFileExcel, faFileImport, faFilePdf, faHome, faPlus, faPlusSquare, faProjectDiagram, faSignOutAlt, faTasks, faUserCircle } from '@fortawesome/free-solid-svg-icons';

@NgModule({
    declarations: [
        DashboardComponent,
        OverviewComponent,
        ProfileComponent,
        ProjectComponent,
        ProjectHeaderComponent,
        NewProjectComponent,
        TableComponentComponent,
        AddTaskDialogComponent,
        MomentPipe        
    ],
    imports: [ 
        CommonModule,
        DashboardRoutingModule,
        AngularMaterialModule,
        FlexLayoutModule,
        NavigationModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        AvatarModule,
        FontAwesomeModule
    ],
    exports: [],
    providers: [JwtValidationGuard],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class DashboardModule { 
    constructor(library: FaIconLibrary) {
        library.addIcons(faTasks, faProjectDiagram, faSignOutAlt, faUserCircle, faPlus, 
                         faFileImport, faFilePdf, faFilePdf, faFileExcel, faFileExcel, faHome)
    }
}