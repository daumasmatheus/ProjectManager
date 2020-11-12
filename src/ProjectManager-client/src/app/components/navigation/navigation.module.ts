import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccessDeniedComponent } from './access-denied/access-denied.component';
import { RouterModule } from '@angular/router';
import { NotFoundComponent } from './not-found/not-found.component';
import { FooterComponent } from './footer/footer.component';
import { AngularMaterialModule } from 'src/app/angular-material.module';

@NgModule({
    declarations: [
        AccessDeniedComponent, 
        NotFoundComponent,
        FooterComponent
    ],
    imports: [ 
        CommonModule,
        RouterModule,
        AngularMaterialModule 
    ],
    exports: [
        FooterComponent
    ],
    providers: [],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class NavigationModule {}