import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccessDeniedComponent } from './access-denied/access-denied.component';
import { RouterModule } from '@angular/router';
import { NotFoundComponent } from './not-found/not-found.component';

@NgModule({
    declarations: [
        AccessDeniedComponent, 
        NotFoundComponent
    ],
    imports: [ 
        CommonModule,
        RouterModule 
    ],
    exports: [],
    providers: [],
})
export class NavigationModule {}