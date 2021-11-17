import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployeeService } from 'src/app/core/services/employee.service';
import { Employee } from 'src/app/shared/models/employee';

@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.css']
})
export class EmployeeDetailComponent implements OnInit {

  employee:Employee | undefined;
  id: number =-1;



  constructor(private employeeService : EmployeeService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      params => {
        this.id = Number(params?.get('id'));
        this.getEmployeeDetail();
      }
    );
  }
  private getEmployeeDetail() {
    this.employeeService.getEmployeeDetailById(this.id)
      .subscribe(c => {
        this.employee = c;
      });

    }
}
