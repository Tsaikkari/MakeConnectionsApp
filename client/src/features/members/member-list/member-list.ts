import { Component, inject, OnInit, signal } from '@angular/core';
import { MemberService } from '../../../core/services/member-service';
import { Member } from '../../../types/members';
import { MemberCard } from "../member-card/member-card";

@Component({
  selector: 'app-member-list',
  imports: [MemberCard],
  templateUrl: './member-list.html',
  styleUrl: './member-list.css'
})
export class MemberList implements OnInit {
  private memberService = inject(MemberService);
  protected members = signal<Member[]>([]);
  protected readonly title = 'Members';

  ngOnInit(): void {
    this.memberService.getMembers().subscribe({
      next: res => this.members.set(res.items),
      error: err => console.log(err)
    });
  }
}