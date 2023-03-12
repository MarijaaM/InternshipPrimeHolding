import { WorkTask } from "./workTask";

export class Project
{
    id:number=0;
    name:string="";
    description:string="";
    clientName="";
    workTasks:Array<WorkTask>=new Array<WorkTask>();
}