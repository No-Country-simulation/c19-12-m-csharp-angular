export interface Card {
  id_user: IdCard;
  fullName: string;
  category: string;
  cantReviews: number;
  ranking: number;
  picUrl: string;
}

export type IdCard = number;
