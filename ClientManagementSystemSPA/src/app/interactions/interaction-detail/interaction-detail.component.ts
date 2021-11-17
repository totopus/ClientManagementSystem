import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { InteractionService } from 'src/app/core/services/interaction.service';
import { Interaction } from 'src/app/shared/models/interaction';

@Component({
  selector: 'app-interaction-detail',
  templateUrl: './interaction-detail.component.html',
  styleUrls: ['./interaction-detail.component.css']
})
export class InteractionDetailComponent implements OnInit {

  interaction:Interaction | undefined;
  id: number =-1;



  constructor(private interactionService : InteractionService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      params => {
        this.id = Number(params?.get('id'));
        this.getInteractionDetail();
      }
    );
  }
  private getInteractionDetail() {
    this.interactionService.getInteractionDetailById(this.id)
      .subscribe(c => {
        this.interaction = c;
      });

    }
}
