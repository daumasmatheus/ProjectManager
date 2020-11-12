import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { DashboardComponent } from './dashboard.app.component';
import { OverviewComponent } from './overview/overview.component';
import { TasksComponent } from './tasks/tasks.component';
import { ProjectsComponent } from './projects/projects.component';
import { JwtValidationGuard } from './guards/jwt-validation.guard';

const routes: Routes = [
    {
        path: '', component: DashboardComponent, canActivate: [JwtValidationGuard],
        children: [     
            { path: '', pathMatch: 'full', redirectTo: 'overview'},       
            { path: 'overview', component: OverviewComponent },
            { path: 'tasks', component: TasksComponent },
            { path: 'projects', component: ProjectsComponent }            
        ]
    }
    //{ path: 'path/:routeParam', component: MyComponent },
    //{ path: 'staticPath', component: ... },
    //{ path: '**', component: ... },
    //{ path: 'oldPath', redirectTo: '/staticPath' },
    //{ path: ..., component: ..., data: { message: 'Custom' }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class DashboardRoutingModule {}
