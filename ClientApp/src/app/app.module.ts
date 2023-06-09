import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeesComponent } from './components/employees/employees.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavigationComponent } from './components/navigation/navigation.component';
import { EmployeeService } from './services/employee.service';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { EmployeeDetailsComponent } from './components/employee-details/employee-details.component';
import { MatDialogModule } from '@angular/material/dialog'; 
import { WorkTaskDetailsComponent } from './components/work-task-details/work-task-details.component';
import { ProjectComponent } from './components/project/project.component';
import { ProjectsComponent } from './components/projects/projects.component';
import { ProjectAddComponent } from './components/project-add/project-add.component';
import { StatisticsComponent } from './components/statistics/statistics.component';
import { BestEmployeesComponent } from './components/best-employees/best-employees.component';

@NgModule({
  declarations: [
    AppComponent,
    EmployeesComponent,
    NavigationComponent,
    EmployeeDetailsComponent, 
    WorkTaskDetailsComponent,
    ProjectComponent,
    ProjectsComponent,
    ProjectAddComponent,
    StatisticsComponent,
    BestEmployeesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MatDialogModule,
    HttpClientModule 
  ],
  providers: [EmployeeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
