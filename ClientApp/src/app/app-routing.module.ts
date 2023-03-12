import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeesComponent } from './components/employees/employees.component';
import { ProjectComponent } from './components/project/project.component';
import { ProjectsComponent } from './components/projects/projects.component';
import { WorkTasksComponent } from './components/work-tasks/work-tasks.component';
import { StatisticsComponent } from './statistics/statistics.component';

const routes: Routes = [ 
  { path:"", component:  EmployeesComponent},
  { path:"employees", component:  EmployeesComponent},
  {path:"workTasks",component:WorkTasksComponent},
  {path:"projects",component:ProjectsComponent},
  {path:"statistics",component:StatisticsComponent},
  {path:"project/:id",component:ProjectComponent}
]; 
 

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
