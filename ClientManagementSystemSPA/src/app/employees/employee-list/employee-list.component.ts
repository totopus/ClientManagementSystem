import { EmployeeService } from '../../core/services/employee.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Employee } from 'src/app/shared/models/employee';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  employees:Employee[]=[];
  employeeId: number = -1;

  constructor(private employeeService:EmployeeService,
    private route:ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.employeeService.getAllEmployees()
        .subscribe(c => {
          this.employees = c;
        });
    }
  );
  }

}
