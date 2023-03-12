import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeesComponent } from './components/employees/employees.component';
import { ProjectComponent } from './components/project/project.component';
import { ProjectsComponent } from './components/projects/projects.component'; 
import { StatisticsComponent } from './components/statistics/statistics.component';
import { BestEmployeesComponent } from './components/best-employees/best-employees.component';

const routes: Routes = [ 
  { path:"", component:  EmployeesComponent},
  { path:"employees", component:  EmployeesComponent}, 
  {path:"projects",component:ProjectsComponent},
  {path:"best-employees",component:BestEmployeesComponent},
  {path:"statistics",component:StatisticsComponent},
  {path:"project/:id",component:ProjectComponent}
]; 
 

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
