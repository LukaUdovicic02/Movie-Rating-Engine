export type ContentType = "Movie" | "TVShow";

export type ContentDto = {
  id: string;
  title: string;
  description: string;
  releaseDate: string;
  type: ContentType;
  imageURL: string;
};

export type ReviewCreateDto = {
  contentId: string;
  rating: number;
};

export type ReviewDto = {
  id: string;
  rating: number;
};

export type ContentDetailDto = {
  id: string;
  title: string;
  description: string;
  releaseDate: string;
  imageURL: string;
  type: "Movie" | "TVShow";
  averageRating: number;
  ratingCount: number;
  casts: { id: string; name: string }[];
};
