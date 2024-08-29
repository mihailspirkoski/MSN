export interface IForumPost {
    id: string,
    title: string,
    artist: string,
    isApproved: boolean,
    type: number,
    genre: number,
    description: string,
    timeCreated: Date,
    userName: string,
    createdBy: any
}