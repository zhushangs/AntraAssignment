export interface Client {
      id: number;
      name: string;
      email: string;
      phones: string;
      address?: any;
      addedBy: number;
      addedOn: Date;
}