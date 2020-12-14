class Article {
    comments = [];
    _likes = [];

    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
    }

    get likes() {
        let output = '';

        if (this._likes.length == 0) {
            output = `${this.title} has 0 likes`;
        } else if (this._likes.length == 1) {
            output = `${this._likes[0]} likes this article!`;
        } else {
            output = `${this._likes[0]} and ${this._likes.length - 1} others like this article!`;
        }

        return output;
    }

    like(username) {
        if (this._likes.includes(username)) {
            throw new Error('You can\'t like the same article twice!');
        } else if (username == this.creator) {
            throw new Error('You can\'t like your own articles!');
        }

        this._likes.push(username);
        return `${username} liked ${this.title}!`;
    }

    dislike(username) {
        if (!this._likes.includes(username)) {
            throw new Error('You can\'t dislike this article!');
        }

        let user = this._likes.find(u => u == username);
        let index = this._likes.indexOf(user);
        this._likes.splice(index, 1);

        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id) {
        let output = '';
        let commentId = id;

        if (commentId == undefined || !this.comments.some(c => c.id == commentId)) {
            this.comments.push({ id: this.comments.length + 1, username, content, replies: [] });

            output = `${username} commented on ${this.title}`;
        } else if (this.comments.some(c => c.id == commentId)) {
            let comment = this.comments.find(c => c.id == commentId);
            if (comment.replies.length == 0) {
                let id = (commentId + 0.1).toFixed(1);
                comment.replies.push({ id, username, content });
            } else {
                let { id } = comment.replies[comment.replies.length - 1];
                id = Number(id);
                id = (id + 0.1).toFixed(1);
                comment.replies.push({ id, username, content });
            }

            output = `You replied successfully`;
        }

        return output;
    }

    toString(sortingType) {
        switch (sortingType) {
            case 'asc':
                this.comments.sort((a, b) => a.id - b.id);
                this.comments.forEach(comment => {
                    comment.replies.sort((a, b) => a.id - b.id);
                })
                break;
            case 'desc':
                this.comments.sort((a, b) => b.id - a.id);
                this.comments.forEach(comment => {
                    comment.replies.sort((a, b) => b.id - a.id);
                })
                break;
            case 'username':
                this.comments.sort((a, b) => a.username.localeCompare(b.username));
                this.comments.forEach(comment => {
                    comment.replies.sort((a, b) => a.username.localeCompare(b.username));
                })
                break;
        }

        let output = `Title: ${this.title}\n`;

        output += `Creator: ${this.creator}\n`;
        output += `Likes: ${this._likes.length}\n`;
        output += 'Comments:\n';

        if (this.comments.length > 0) {
            this.comments.forEach(comment => {
                output += `-- ${comment.id}. ${comment.username}: ${comment.content}\n`;
                if (comment.replies.length > 0) {
                    comment.replies.forEach(reply => {
                        output += `--- ${reply.id}. ${reply.username}: ${reply.content}\n`;
                    })
                }
            })
        }

        return output.trim();
    }
}

let art = new Article("My Article", "Anny");
art.like("John")
console.log(art.likes);
art.like("Ivan")
art.like("Steven")
console.log(art.likes);
art.comment("Anny", "Some Content")
art.comment("Ammy", "New Content", 1)
art.comment("Zane", "Reply", 2)
art.comment("Jessy", "Nice :)")
console.log(art.comment("SAmmy", "Reply@", 2))
console.log(art.toString('asc'));