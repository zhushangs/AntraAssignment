import { InteractionUpdateComponent } from './interaction/interaction-update/interaction-update.component';
import { InteractionCreateComponent } from './interaction/interaction-create/interaction-create.component';
import { EmployeeUpdateComponent } from './employee/employee-update/employee-update.component';
import { ClientUpdateComponent } from './client/client-update/client-update.component';
import { ClientCreateComponent } from './client/client-create/client-create.component';
import { InteractionDetailsComponent } from './interaction/interaction-details/interaction-details.component';
import { InteractionListComponent } from './interaction/interaction-list/interaction-list.component';
import { ClientDetailsComponent } from './client/client-details/client-details.component';
import { ClientListComponent } from './client/client-list/client-list.component';
import { EmployeeDetailsComponent } from './employee/employee-details/employee-details.component';
import { EmployeeListComponent } from './employee/employee-list/employee-list.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';

const routes: Routes = 
[
  { path:"", component: HomeComponent },
  { path:"login", component: LoginComponent },
  { path: "register", component: RegisterComponent },

  { path: "employees", component: EmployeeListComponent },
  { path: "employees/:id", component: EmployeeDetailsComponent},
  { path: "employees/update/:id", component: EmployeeUpdateComponent},

  { path: "clients", component: ClientListComponent },
  { path: "clients/create", component: ClientCreateComponent},
  { path: "clients/update/:id", component: ClientUpdateComponent},
  { path: "clients/:id", component: ClientDetailsComponent},

  { path: "interactions", component: InteractionListComponent },
  { path: "interactions/create", component: InteractionCreateComponent},
  { path: "interactions/update/:id", component: InteractionUpdateComponent},
  { path: "interactions/:id", component: InteractionDetailsComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
