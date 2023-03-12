import { Employee } from "./employee";
import { Project } from "./project";
import { TaskState } from "./taskState";
import { TaskStateRecord } from "./taskStateRecord";

export class WorkTask
{

    id:number=0;
    title:string="";
    description:string="";
    dueDate:Date=new Date();
    state:TaskState=TaskState.ToDo;
    assignee:Employee=new Employee();
    states:Array<TaskStateRecord>=new Array<TaskStateRecord>();
    project:Project=new Project();
    projectId:number=0;
}
