import './styles.css';
import {Component} from 'react';

import { loadPosts as api }  from '../../utils/load-posts';
import { Posts } from '../../components/Posts';
import { Button } from '../../components/Button';
import { TextInput } from '../../components/TextInput';


export class Home extends Component {
  state = {
    posts: [],
    allPosts: [],
    page: 0,
    postsPerPage: 3,
    searchValue:""
  };

  componentDidMount() {
    this.loadPosts();
  }

  loadPosts = async () => {
    const { page, postsPerPage } = this.state;
    const postsAndPhotos = await api();
    this.setState({ 
      posts: postsAndPhotos.slice(page, postsPerPage),
      allPosts: postsAndPhotos,
    });
  }

  loadMorePosts =  () => {
    const {
      page,
      postsPerPage,
      allPosts,
      posts,
    } = this.state;
    const nextPage = page + postsPerPage;
    const nextPosts = allPosts.slice(nextPage, nextPage + postsPerPage);

    posts.push(...nextPosts);

    this.setState({posts, page: nextPage})
  }

  handleChange = (e) =>{
    const {value} = e.target;
    this.setState({ searchValue: value});
  }


  render() {
    const { posts, page, postsPerPage, allPosts, searchValue } = this.state;
    const noMorePosts = page + postsPerPage >= allPosts.length;

    const filteredPosts = !!searchValue ? allPosts.filter(posts => {

      // console.log(e);
      return posts.title.toLowerCase()
      .includes(searchValue.toLowerCase());
    }) : posts;

    return (
      <section className="container">
        <div class="search-container">
            {!!searchValue && (
              <h1>Search Value: {searchValue}</h1>
            )}

          <TextInput searchValue={searchValue} handleChange={this.handleChange} />
        </div>

      {filteredPosts.length > 0 && (
        <Posts posts={filteredPosts} />
        )}

      {filteredPosts.length === 0 && (
        <p>Não existem posts =( </p>
      )}

        <div className="button-container">

          {!searchValue && (        
          <Button 
          text="carregar mais posts"
          onClick={this.loadMorePosts}
          disabled={noMorePosts}
           />)}

        </div>

      </section>
    );
  }
}


	
