import { Component, OnInit } from '@angular/core';
import { WorkTaskStats } from 'src/app/models/workTaskStats';
import { WorktaskService } from 'src/app/services/worktask.service';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {
  
  stats:Array<WorkTaskStats> =new Array<WorkTaskStats>();
  constructor(private workTaskService:WorktaskService) { 
      workTaskService.GetStatistics().subscribe(x=>this.stats=x);
  }
  ngOnInit(): void {
  }

}
