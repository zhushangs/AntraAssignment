import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './core/layout/header/header.component';
import { FooterComponent } from './core/layout/footer/footer.component';


import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { EmployeeListComponent } from './employee/employee-list/employee-list.component';
import { EmployeeDetailsComponent } from './employee/employee-details/employee-details.component';
import { ClientListComponent } from './client/client-list/client-list.component';
import { ClientDetailsComponent } from './client/client-details/client-details.component';
import { InteractionListComponent } from './interaction/interaction-list/interaction-list.component';
import { InteractionDetailsComponent } from './interaction/interaction-details/interaction-details.component';
import { ClientCreateComponent } from './client/client-create/client-create.component';
import { ClientUpdateComponent } from './client/client-update/client-update.component';
import { EmployeeUpdateComponent } from './employee/employee-update/employee-update.component';
import { InteractionCreateComponent } from './interaction/interaction-create/interaction-create.component';
import { InteractionUpdateComponent } from './interaction/interaction-update/interaction-update.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    EmployeeListComponent,
    EmployeeDetailsComponent,
    ClientListComponent,
    ClientDetailsComponent,
    InteractionListComponent,
    InteractionDetailsComponent,
    ClientCreateComponent,
    ClientUpdateComponent,
    EmployeeUpdateComponent,
    InteractionCreateComponent,
    InteractionUpdateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbDropdownModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
