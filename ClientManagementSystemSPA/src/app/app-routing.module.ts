import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeDetailComponent } from './employees/employee-detail/employee-detail.component';
import { EmployeeListComponent } from './employees/employee-list/employee-list.component';
import { HomeComponent } from './home/home.component';
import { ClientDetailComponent } from './clients/client-detail/client-detail.component';
import { ClientListComponent } from './clients/client-list/client-list.component';
import { InteractionDetailComponent } from './interactions/interaction-detail/interaction-detail.component';
import { InteractionListComponent } from './interactions/interaction-list/interaction-list.component';

const routes: Routes =
  [
    { path: '', component: HomeComponent },
    { path: 'employees', component: EmployeeListComponent },
    { path: 'employees/:id', component: EmployeeDetailComponent },

    { path: 'clients', component: ClientListComponent },
    { path: 'clients/:id', component: ClientDetailComponent },
    { path: 'interactions', component: InteractionListComponent },
    { path: 'interactions/:id', component: InteractionDetailComponent }
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
