import React from 'react'
import "./Card.css";
type Props = {}

const Card = (props: Props) => {
  return (
    <div className='card'>
        <img
            src ="https://cdn.discordapp.com/attachments/858929848080138241/1241282079287672902/parcel.png?ex=6649a185&is=66485005&hm=0881590d27e23bfd933fd2e817b26a482133dcdca0fabe214ab3bc4d17fdde4b&"
            alt="parcel"
        />
        <div className='details'>
            <h2>Parcel</h2>
            <p>Parcel is a package manager for JavaScript, which we use to manage our dependencies.
                </p>       
        </div>
        <p className='info'>Lorem ipsum dolor sit amet consectetur adipisicing elit. Explicabo, repellat.
        </p>
    </div>
  )
}

export default Card