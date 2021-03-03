export interface Blog {
    blogId: number;
    title: string;
    content: string;
    userId: number;
    username: string;
    publishDate: Date;
    updateDate: Date;
    deleteConfirm: boolean;
    photoId?: number
}