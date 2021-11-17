import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './core/layout/header/header.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { EmployeeDetailComponent } from './employees/employee-detail/employee-detail.component';
import { EmployeeListComponent } from './employees/employee-list/employee-list.component';
import { HomeComponent } from './home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { ClientDetailComponent } from './clients/client-detail/client-detail.component';
import { ClientListComponent } from './clients/client-list/client-list.component';
import { InteractionListComponent } from './interactions/interaction-list/interaction-list.component';
import { InteractionDetailComponent } from './interactions/interaction-detail/interaction-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    EmployeeDetailComponent,
    EmployeeListComponent,
    ClientDetailComponent,
    ClientListComponent,
    InteractionListComponent,
    InteractionDetailComponent,
    HomeComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
